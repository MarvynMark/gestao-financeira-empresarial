using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace PenielBikeControle.Utils
{
    public class ControllerUtils
    {
        public static (bool EhValido, List<string> ListaDeErros) ValidaModel(object objModel)
        {
            var listaDeErros = new List<string>();
            if (objModel is null)
            {
                listaDeErros.Add("objModel is null");
                return (false, listaDeErros);
            }
            var objType = objModel.GetType();
            var objProperties = objType.GetProperties();

            (bool EhValido, List<string> ListaDeErros) resumo = (false, new List<string>());

            listaDeErros = RetornaMensagensDeErro(objModel);

            if (listaDeErros.Any())
                resumo.ListaDeErros.AddRange(listaDeErros);

            foreach (PropertyInfo property in objProperties)
            {
                if (property.PropertyType.IsClass)
                {
                    listaDeErros = RetornaMensagensDeErro(property.GetValue(objModel));
                    resumo.ListaDeErros.AddRange(listaDeErros);
                }
            }

            resumo.EhValido = !resumo.ListaDeErros.Any();

            return resumo;
        }
        private static List<string> RetornaMensagensDeErro(object? obj)
        {
            if (obj == null)
                return new List<string>();

            var validationResult = new List<ValidationResult>();
            var validationContext = new ValidationContext(obj);
            Validator.TryValidateObject(obj, validationContext, validationResult, true);

            List<string> listaDeErros = new();

            if (validationResult.Count > 0)
            {
                foreach (var result in validationResult)
                {
                    if (result.ErrorMessage != null)
                        listaDeErros.Add(result.ErrorMessage);
                }
            }

            return listaDeErros;
        }


        public static JsonResult RetornoJsonResult(bool sucesso, string mensagem, List<string>? listaErros = null)
        {
            return new JsonResult(
                        new
                        {
                            Sucesso = sucesso,
                            Mensagem = mensagem,
                            ListaErros = listaErros
                        });
        }

        public static JsonResult RetornoJsonResult(bool sucesso, object objResult)
        {
            return new JsonResult(
                        new
                        {
                            Sucesso = sucesso,
                            ObjResult = objResult
                        });
        }

        public static JsonResult RetornoJsonResult(Exception ex)
        {
            var msgsErros = new StringBuilder();

            msgsErros.AppendLine($"Erro: {ex.Message}. \n");
            
            if (ex.InnerException is not null)
            {
                msgsErros.AppendLine($"InnerException: {ex.InnerException.Message}");
            }

            return new JsonResult(
                        new
                        {
                            Sucesso = false,
                            Mensagem = msgsErros.ToString(),
                        });
        }
    }
}

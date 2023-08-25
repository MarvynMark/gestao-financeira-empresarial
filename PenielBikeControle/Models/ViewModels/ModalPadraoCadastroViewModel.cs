
namespace PenielBikeControle.Models.ViewModels
{
    public class ModalPadraoCadastroViewModel
    {
        public int? Id { get; set; }
        public bool ModoEdicao { get; set; }
        public string NomePartialView { get; set; }
        public object ParamModel { get; set; }

        public ModalPadraoCadastroViewModel()
        {

        }

        public ModalPadraoCadastroViewModel(int? id, bool modoEdicao, string nomePartialView, object paramModel)
        {
            Id = id;
            ModoEdicao = modoEdicao;
            NomePartialView = nomePartialView;
            ParamModel = paramModel;
        }
    }
}
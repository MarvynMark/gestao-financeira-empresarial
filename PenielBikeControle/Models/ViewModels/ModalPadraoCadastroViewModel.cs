
namespace PenielBikeControle.Models.ViewModels
{
    public class ModalPadraoCadastroViewModel
    {
        public ModalPadraoCadastroViewModel() {}
        
        public int? Id { get; set; }
        public bool ModoEdicao { get; set; }
        public bool ModoVisualizacao { get; set; }
        public string NomePartialView { get; set; } = string.Empty;
        public object ParamModel { get; set; } = new object();
    }
}
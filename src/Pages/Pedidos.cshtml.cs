using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosPradom.Services;
using System;
using System.Threading.Tasks;

namespace PedidoSyncWeb.Pages
{
    public class PedidosModel(IntegrationService integrationService) : PageModel
    {
        private readonly IntegrationService _integrationService = integrationService;

        public string UltimaAtualizacao { get; set; }
        public string UltimoAtualizador { get; set; } = "-";
        public string MensagemRetorno { get; set; } = "";

        [BindProperty]
        public string NomeAtualizador { get; set; }

        [BindProperty]
        public string CodigoPedido { get; set; }

        [BindProperty]
        public DateTime DataHoraAtualizacao { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
            DateTime.UtcNow,
            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")
        ).Date;

        //public void OnGet()
        //{
        //    DataHoraAtualizacao = DateTime.Today;
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(NomeAtualizador))
            {
                try
                {
                    int[] ids = Array.ConvertAll(CodigoPedido.Split(','), int.Parse);
                    foreach(int pedidoId in ids)
                    {
                        await _integrationService.ImportarPedidosAsync(pedidoId: pedidoId, dataFiltro: null);
                    }

                    MensagemRetorno = $"Pedidos {CodigoPedido} importados com sucesso.";

                    UltimaAtualizacao = "Realizada às " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    UltimoAtualizador = NomeAtualizador;
                }
                catch (Exception ex)
                {
                    MensagemRetorno = "Erro na importação: " + ex.Message;
                }
            }

            return Page();
        }
    }
}

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
        public int CodigoPedido { get; set; }

        [BindProperty]
        public DateTime DataHoraAtualizacao { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
            DateTime.UtcNow,
            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")
        );

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(NomeAtualizador))
            {
                try
                {
                    await _integrationService.ImportarPedidosAsync(pedidoId: CodigoPedido, dataFiltro: DataHoraAtualizacao);
                    MensagemRetorno = $"Pedidos após {DataHoraAtualizacao:dd/MM/yyyy} importados com sucesso.";

                    UltimaAtualizacao = "Realizada às " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                                        " a partir de " + DataHoraAtualizacao.ToString("dd/MM/yyyy");
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

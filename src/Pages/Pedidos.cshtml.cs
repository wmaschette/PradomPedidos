using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidosPradom.Services;
using System;
using System.Threading.Tasks;

namespace PedidoSyncWeb.Pages
{
    public class PedidosModel : PageModel
    {
        private readonly IntegrationService _integrationService;

        public PedidosModel(IntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        public string UltimaAtualizacao { get; set; }
        public string UltimoAtualizador { get; set; } = "-";
        public string MensagemRetorno { get; set; } = "";

        [BindProperty]
        public string NomeAtualizador { get; set; }

        [BindProperty]
        public int CodigoPedido { get; set; }

        [BindProperty]
        public DateTime DataHoraAtualizacao { get; set; } = DateTime.Now;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(NomeAtualizador))
            {
                try
                {
                    if (CodigoPedido > 0)
                    {
                        await _integrationService.ImportarPedidosAsync(codigoPedido: CodigoPedido);
                        MensagemRetorno = $"Pedido {CodigoPedido} importado com sucesso.";
                    }
                    else
                    {
                        await _integrationService.ImportarPedidosAsync(dataFiltro: DataHoraAtualizacao);
                        MensagemRetorno = $"Pedidos após {DataHoraAtualizacao:dd/MM/yyyy HH:mm} importados com sucesso.";
                    }

                    UltimaAtualizacao = "Realizada às " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") +
                                        " a partir de " + DataHoraAtualizacao.ToString("dd/MM/yyyy HH:mm");
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

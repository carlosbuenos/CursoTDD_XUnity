using Alura.LeilaoOnline.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
	public class LeilaoRecebeOferta
	{
		[Fact]
		public void IgnoraNovoLancaDadoPregaoFinalizado() {
			var leilao = new Leilao("Quadro Alejadinho");
			var fulano = new Interessada("Fulano", leilao);
			var ciclano = new Interessada("Ciclano", leilao);


			leilao.RecebeLance(fulano, 100);
			leilao.RecebeLance(ciclano, 300);
			leilao.RecebeLance(ciclano, 600);
			

			leilao.TerminaPregao();

			leilao.RecebeLance(fulano, 800);

			var valorEsperado = 600;
			var valorRecebido = leilao.Ganhador.Valor;
			Assert.Equal(valorEsperado, valorRecebido);
		}

		[Theory]
		[InlineData(new string[] { "Teste 1", "Teste2", "Teste3" }, new double[] { 100,200,300,400})]
		public void ExibirOTotalDeLancesDevidoAdicaoDeNovosLances(string[] interessados,double[] valor) {
			var leilao = new Leilao("Quadro Alejadinho");
			foreach (var interessado in interessados)
			{
				foreach (var oferta in valor)
				{
					leilao.RecebeLance(new Interessada(interessado, leilao), oferta);
				}
			}
			leilao.TerminaPregao();

			var totalEsperado = 12;
			var totalRecebido = leilao.Lances.Count;
			Assert.Equal(totalEsperado, totalRecebido);
		}
	}
}

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

			var valorEsperado = 800;
			var valorRecebido = leilao.Ganhador.Valor;
			Assert.Equal(valorEsperado, valorRecebido);
		}
	}
}

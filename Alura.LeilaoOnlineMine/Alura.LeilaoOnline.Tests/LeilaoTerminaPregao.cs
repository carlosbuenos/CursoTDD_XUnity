using Alura.LeilaoOnline.Core.Entidades;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{

	public class LeilaoTerminaPregao
	{
		[Fact]
		public void LeilaoComVariosLances()
		{
			var leilao = new Leilao("Quadro Alejadinho");
			var fulano = new Interessada("Fulano", leilao);
			var ciclano = new Interessada("Ciclano", leilao);


			leilao.RecebeLance(fulano, 100);
			leilao.RecebeLance(ciclano, 300);
			leilao.RecebeLance(ciclano, 600);
			leilao.RecebeLance(fulano, 500);

			leilao.TerminaPregao();
			var valorEsperado = 600;
			var valorRecebido = leilao.Ganhador.Valor;
			Assert.Equal(valorEsperado, valorRecebido);

		}

		[Fact]
		public void LeilaoComUmLance()
		{
			var leilao = new Leilao("Quadro Alejadinho");
			var fulano = new Interessada("Fulano", leilao);
			var ciclano = new Interessada("Ciclano", leilao);


			leilao.RecebeLance(fulano, 100);

			leilao.TerminaPregao();
			var valorEsperado = 100;
			var valorRecebido = leilao.Ganhador.Valor;
			Assert.Equal(valorEsperado, valorRecebido);
		}

		[Fact]
		public void RetornaMaiorValorZeroDadoLeilaoSemLance()
		{
			#region Arrajnje
			var leilao = new Leilao("Quadro Alejadinho");

			#endregion

			#region Act
			leilao.TerminaPregao();
			#endregion

			#region Assert
			var valorEsperado = 0;
			var valorRecebido = leilao.Ganhador.Valor;
			Assert.Equal(valorEsperado, valorRecebido);
			#endregion
		}

		[Theory]
		[InlineData(400,new double[] { 100, 200, 300, 400 })]
		[InlineData(400,new double[] { 100, 200, 400, 300 })]
		[InlineData(100,new double[] { 100 })]
		public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado,double[] ofertas)
		{
			var leilao = new Leilao("Quadro Alejadinho");
			var fulano = new Interessada("Fulano", leilao);

			foreach (var oferta in ofertas)
			{
				leilao.RecebeLance(fulano, oferta);
			}
			

			leilao.TerminaPregao();
			var valorRecebido = leilao.Ganhador.Valor;
			Assert.Equal(valorEsperado, valorRecebido);
		}
	}
}

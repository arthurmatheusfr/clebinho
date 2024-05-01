using System.Text.Json;

namespace clebinhojunior;

public partial class MainPage : ContentPage
{
const string url ="https://api.hgbrasil.com/weather?woeid=455927&key=6de38f65";
	Resposta resposta;

	public MainPage()
	{
		InitializeComponent();

		AtualizaTempo();
		
	}
        async void AtualizaTempo()
		{
			try
			{
				var HttpClient = new HttpClient();
				var Response = await HttpClient.GetAsync(url);
				if (Response.IsSuccessStatusCode)
				{
					var content = await Response.Content.ReadAsStringAsync();
					resposta = JsonSerializer.Deserialize<Resposta>(content);
					PreencherTela();
				}
			}
			catch(Exception e)
			{
             System.Diagnostics.Debug.WriteLine(e);
			}

		}
		void PreencherTela()
			{
				labeltemperatura.Text= resposta.results.temp.ToString();
				labelCeu.Text= resposta.results.description;
				labelCidade.Text= resposta.results.city;
				labelChuva.Text= resposta.results.rain.ToString();
				labelHumidade.Text= resposta.results.humidity.ToString();
				labelAmanhecer.Text= resposta.results.sunrise;
				labelAnoitecer.Text= resposta.results.sunset;
				labelForcavent.Text= resposta.results.wind_speedy.ToString();
				labelDirecaovent.Text= resposta.results.wind_direction.ToString();

				if (resposta.results.moon_phase=="full")
					labelFaselua.Text = "Cheia";

				else if (resposta.results.moon_phase=="new")
					labelMoonFaselua.Text = "Nova";

				else if (resposta.results.moon_phase=="waxing_crescent")
					labelMoonFaselua.Text = "Lua Crescente";

				else if (resposta.results.moon_phase=="first_quarter")
					labelMoonFaselua.Text = "Quarto Crescente";

				else if (resposta.results.moon_phase=="last_quarter")
					labelMoonFaselua.Text = "Quarto Minguante";
				
				else if (resposta.results.moon_phase=="waxing_gibbous")
					labelMoonFaselua.Text = "Gibosa Crescente";
	
				else if (resposta.results.moon_phase=="waxing_crescent")
					labelMoonFaselua.Text = "Gibosa Minguante";
		
				else if (resposta.results.moon_phase=="waning_crescent")
					labelMoonFaselua.Text = "Lua Minguante";
			




				if (resposta.results.currently=="dia")
					{
						if (resposta.results.rain>=10)
							FundoImagem.Source="diachuvoso.jpg";
						else if (resposta.results.cloudiness>=10)
							FundoImagem.Source="dianublado.jpg";
						else
							FundoImagem.Source="dianormal.jfif";
					}
				else
					{
						if (resposta.results.rain>=10)
							FundoImagem.Source="noitechuvosa.png";
						else if (resposta.results.cloudiness>=10)
							FundoImagem.Source="noitenublada.png";
						else
							FundoImagem.Source="noitenormal.png";
					}
			}
}


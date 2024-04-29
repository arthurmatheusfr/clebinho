using System.Text.Json;

namespace clebinhojunior;

public partial class MainPage : ContentPage
{

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

			}

		}
		void TestaLayout()
		{
			resposta.results.temp=21;
			resposta.results.description="Nublado";
			resposta.results.city="Apucarana-PR";
			resposta.results.rain="88.2";
		    resposta.results.humidity="88.2";
			resposta.results.sunrise="6:22";
			resposta.results.sunset="18:44";
			resposta.results.wind_speedy=3;
			resposta.results.wind_direction="373 N";
			resposta.results.moon_phase="Nov";
		
		}
		void PreencherTela()
		{
          temperaturatexto.text= resposta.results.temp.ToString();
		  


		}
}


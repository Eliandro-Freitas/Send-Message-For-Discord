using JNogueira.Discord.Webhook.Client;

namespace LogandoNoDiscord;

public class ConfigureDiscordMessage
{
    const string _photo = "https://media-exp1.licdn.com/dms/image/C4D03AQHBAJPNRJ0vnQ/profile-displayphoto-shrink_200_200/0/1624644938730?e=1647475200&v=beta&t=R6OoB6QSHUsdQvzycHZ6oFcatqRzTycF20YMu1sty08";
    const string _logoMp = "https://media-exp1.licdn.com/dms/image/C4D0BAQF-vGML38Mh-w/company-logo_200_200/0/1594332980405?e=2159024400&v=beta&t=OcB5dr00Qv5DG9ldRBdI1Gci4doKbTw8v4amx7RNCvM";

    public DiscordMessage Message()
    {
        return new(
        $"Discord Hebhook funcionado... Olá Eliandro! {DiscordEmoji.Smile}",
        username: "Eliandro Freitas",
        avatarUrl: _logoMp,
        tts: false,
        embeds: new[]
        {
            new DiscordMessageEmbed(
                $"Redirecionar para Linkedin de Eliandro {DiscordEmoji.Computer}",
                author: new DiscordMessageEmbedAuthor("Eliandro Freitas"),
                url: "https://www.linkedin.com/in/eliandrofreitas/",
                description: "Teste de robo para mensagem",
                image: new DiscordMessageEmbedImage(_photo),
                footer: new DiscordMessageEmbedFooter("MeuPortfolio",_logoMp))
        });
    }
}
using examen_md.Services.Interface;

namespace examen_md.Services
{
    public class MaximumSimultaneousGamesService: IMaximumSimultaneousGamesService
    {
        public int MaximumSimultaneousGames(int playersNumber, int fieldsNuimber)
        {
            // Calcula el número máximo de juegos simultáneos que se pueden jugar dividendo el número de jugadores entre 2
            // y comparándolo con el número de canchas disponibles y devolviendo el valor más pequeño.
            int maxNumberOfGames = Math.Min(playersNumber / 2, fieldsNuimber);

            return maxNumberOfGames;
        }

    }
}

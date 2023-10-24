namespace examen_md.Models
{
    public class Punto3D : Punto2D
    {
        public int z;

        public Punto3D(int x, int y, int z) : base(x, y)
        {
            this.z = z;
        }

    }
}

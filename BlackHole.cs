using System.Drawing;

public class BlackHole
{
    public double PosX, PosY, PosZ, VelX, VelY, VelZ, Mass;
    public Color Color;
    public readonly int ID;
    private static int BlackHoleIDs = 0;

    public BlackHole()
    {
        ID = BlackHoleIDs++;
    }

    public void Clear()
    {
        PosX = 0;
        PosY = 0;
        PosZ = 0;
        VelX = 0;
        VelY = 0;
        VelZ = 0;
        Mass = 0;
        Color = Color.White;
    }
}
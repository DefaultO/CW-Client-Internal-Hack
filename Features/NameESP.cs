namespace CW_Internal_Hack.Hacks
{
    class NameESP
    {
        // Screen turns blank / black after joining a match. Have to debug that one.
        // After having looked more into the Assembly-CSharp.dll,
        // I've found out that they check if you try to get the value from the same Assembly.
        // You can patch it out using dnSpy or libraries like Harmony that does patches in runtime
    }
}

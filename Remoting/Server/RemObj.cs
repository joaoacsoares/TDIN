using System;

public class RemObj: MarshalByRefObject
{
  public RemObj()
  {
    Console.WriteLine("Constructor called");
  }

  public string Hello()
  {
    Console.WriteLine("Hello called");
    return "Hello .NET client!";
  }

  public string Modify(ref int val)
  {
    string s = String.Format("Received: {0}", val);

    Console.WriteLine("Modify called");
    Console.WriteLine(s);
    val += 10;
    return s;
  }
}

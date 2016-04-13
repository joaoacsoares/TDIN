using System;

public class RemObj: MarshalByRefObject
{
  public string Hello()
  {
    return null;
  }

  public string Modify(ref int val)
  {
    return null;
  }
}

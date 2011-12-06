using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Security.Principal;
using System.Threading;
using prep.utility.filtering;

namespace prep.utility
{
  public class SecuredEnumerable<T> : IEnumerable<T>
  {
    IMatchAn<IPrincipal> security_constraint;
    IEnumerable<T> items;

    public SecuredEnumerable(IMatchAn<IPrincipal> security_constraint, IEnumerable<T> items)
    {
      this.security_constraint = security_constraint;
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      if (! security_constraint.matches(Thread.CurrentPrincipal)) throw new SecurityException();
      foreach (var item in items)
        yield return item;
    }
  }
}
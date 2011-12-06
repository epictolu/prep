using System;
using System.Collections;
using System.Collections.Generic;

namespace prep.utility
{
  public class MappingEnumerable<Input, Output> : IEnumerable<Output>
  {
    Converter<Input, Output> mapper;
    IEnumerable<Input> items;

    public MappingEnumerable(Converter<Input, Output> mapper, IEnumerable<Input> items)
    {
      this.mapper = mapper;
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<Output> GetEnumerator()
    {
      foreach (var item in items)
        yield return mapper(item);
    }
  }
}
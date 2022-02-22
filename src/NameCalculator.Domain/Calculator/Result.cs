using System;
using Volo.Abp.Domain.Entities;

namespace NameCalculator.Calculator;

public class Result : AggregateRoot<Guid>
{
    protected Result()
    {
    }

    public Result(Guid id) : base(id)
    {
    }

    public virtual int Counter { get; protected set; }

    public virtual string Output { get; protected set; }

    public virtual Guid OperationFlag { get; protected set; }
}
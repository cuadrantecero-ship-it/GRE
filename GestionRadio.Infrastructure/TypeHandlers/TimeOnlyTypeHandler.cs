using System.Data;
using Dapper;

namespace GestionRadio.Infrastructure.TypeHandlers;

public sealed class TimeOnlyTypeHandler : SqlMapper.TypeHandler<TimeOnly>
{
    public override void SetValue(IDbDataParameter parameter, TimeOnly value)
    {
        parameter.Value = value.ToTimeSpan();
        parameter.DbType = DbType.Time;
    }

    public override TimeOnly Parse(object value)
    {
        return value switch
        {
            TimeSpan ts => TimeOnly.FromTimeSpan(ts),
            DateTime dt => TimeOnly.FromDateTime(dt),
            _ => throw new DataException($"Cannot convert {value.GetType()} to TimeOnly.")
        };
    }
}
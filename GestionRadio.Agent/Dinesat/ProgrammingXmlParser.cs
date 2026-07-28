using System.Xml.Linq;
using GestionRadio.Agent.Models;

namespace GestionRadio.Agent.Dinesat;

public class ProgrammingXmlParser
{
    public List<ProgrammingBlock> Parse(string xml)
    {
        var resultado = new List<ProgrammingBlock>();

        if (string.IsNullOrWhiteSpace(xml))
            return resultado;

        var doc = XDocument.Parse(xml);

        var bloques = doc.Descendants("Programming")
            .GroupBy(x => new
            {
                PgmBlockId = GetInt(x, "PGMBLOCKID"),
                Description = GetString(x, "DESCRIPTION"),
                BlockTime = GetString(x, "BLOCKTIME")
            });

        foreach (var grupo in bloques)
        {
            var bloque = new ProgrammingBlock
            {
                PgmBlockId = grupo.Key.PgmBlockId,
                Description = grupo.Key.Description,
                BlockTime = TimeSpan.TryParse(grupo.Key.BlockTime, out var hora)
                    ? hora
                    : TimeSpan.Zero
            };

            foreach (var item in grupo)
            {
                bloque.Events.Add(new ProgrammingEvent
                {
                    PgmEventId = GetInt(item, "PGMEVENTID"),
                    ItemId = GetInt(item, "ITEMID"),
                    MaterialId = GetInt(item, "MATERIALID"),
                    Condition = GetInt(item, "CONDITION"),
                    TrafficCode = GetString(item, "TRAFFICCODE"),
                    Code = GetString(item, "CODE"),
                    Title = GetString(item, "TITLE"),
                    CategoryName = GetString(item, "CATEGORYNAME"),
                    Length = GetInt(item, "LENGTH"),
                    PriorityId = GetInt(item, "PRIORITYID"),
                    ArtistName = GetString(item, "ARTISTNAME")
                });
            }

            resultado.Add(bloque);
        }

        return resultado;
    }

    private static string GetString(XElement element, string name)
    {
        return element.Element(name)?.Value?.Trim() ?? string.Empty;
    }

    private static int GetInt(XElement element, string name)
    {
        var valor = GetString(element, name);

        return int.TryParse(valor, out var numero)
            ? numero
            : 0;
    }
}
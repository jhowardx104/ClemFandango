using CouchDB.Driver.Types;

namespace ClemFandango.Common.CouchDb.Documents;

public class Document<T>: CouchDocument
{
    public string Id { get; set; }
    public long Revision { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public T Data { get; set; }
}
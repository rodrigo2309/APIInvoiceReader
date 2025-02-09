namespace APIInvoiceReader.Service
{
  public interface IReaderService
  {
    ReaderResponse Get(ReaderRequest request);
  }
}
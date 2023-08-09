namespace StockApp.Application.MessageBus;

public interface IMessageBus
{
    void SendSaleGoodsMessage < T > (T message);
}
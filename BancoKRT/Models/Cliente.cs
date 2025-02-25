using Amazon.DynamoDBv2.DataModel;

namespace BancoKRT.Models
{
    [DynamoDBTable("Banco_KRT")]
    public class Cliente
    {
        [DynamoDBHashKey("CPF")]
        public string CPF { get; set; }

        [DynamoDBProperty]
        public string NumeroAgencia { get; set; }

        [DynamoDBProperty]
        public string NumeroConta { get; set; }

        [DynamoDBProperty]
        public float LimitePIX { get; set; }

        [DynamoDBProperty]
        public float LimitePIXAtual { get; set; }

    }
}

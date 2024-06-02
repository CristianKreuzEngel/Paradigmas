using System.Linq;
using ApiWebDB.BaseDados.Models2;
using ApiWebDB.Services.Exceptions;

namespace ApiWebDB.Services.Validate
{
    public class ProductValidator
    {
        public static void Validate(TbProduct product)
        {
            if (string.IsNullOrEmpty(product.Description))
                throw new InvalidEntityException("Descrição é obrigatória.");

            if (string.IsNullOrEmpty(product.Barcode))
                throw new InvalidEntityException("Código de barras é obrigatório.");

            if (product.Barcode.Length > 40)
                throw new InvalidEntityException("Código de barras não pode ter mais de 40 caracteres.");

            if (string.IsNullOrEmpty(product.Barcodetype))
                throw new InvalidEntityException("Tipo de código de barras é obrigatório.");

            if (product.Stock < 0)
                throw new InvalidEntityException("Estoque deve ser maior ou igual a zero.");

            if (product.Price < 0)
                throw new InvalidEntityException("Preço de venda deve ser maior ou igual a zero.");

            if (product.Costprice < 0)
                throw new InvalidEntityException("Preço de custo deve ser maior ou igual a zero.");


            switch (product.Barcodetype){
                case "EAN-13":
                    if (!(product.Barcode.Length == 13 && product.Barcode.All(char.IsDigit))){
                        throw new InvalidEntityException("Código de barras é inválido.");
                    };
                    break;
                case "DUN-14":
                    if (!(product.Barcode.Length == 14 && product.Barcode.All(char.IsDigit))){
                        throw new InvalidEntityException("Código de barras é inválido.");
                    }
                    break;
                case "UPC":
                    if (!(product.Barcode.Length == 12 && product.Barcode.All(char.IsDigit))){
                        throw new InvalidEntityException("Código de barras é inválido.");
                    };
                    break;
                case "CODE 11":
                    if (!(product.Barcode.Length <= 30 && product.Barcode.All(c => char.IsDigit(c) || c == '-' || c == '*'))){
                        throw new InvalidEntityException("Código de barras é inválido.");
                    }
                    break;
                case "CODE 39":
                    if (!(product.Barcode.Length <= 30 && product.Barcode.All(c => char.IsLetterOrDigit(c) || "-.$/+% ".Contains(c)))){
                        throw new InvalidEntityException("Código de barras é inválido.");
                    }
                    break;
                default:
                    throw new InvalidEntityException("Código de barras inválido ou não informdado.");
            }
        }
    }
}


using ECommerceApi.Model;
using ECommerceApi.RepositoryInterface;
using ECommerceCustomerOrder.Model;

namespace ECommerceApi.RepositoryService
{
    public class ProductService:IProduct
    {
        public ECommmerceDbContext Db;

        public ProductService(ECommmerceDbContext Obj)
        {
            Db = Obj;
        }


        public IEnumerable<Product> GetProductDetail()
        {
            try
            {
                var product = Db.Product.ToList();

                return product;

            }
            catch (Exception)
            {
                throw new Exception("the product list is empty");
            }
        }

        public Product GetProductDetailsById(int productId)
        {
            try
            {
                var product = Db.Product.Find(productId);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Product GetProductDetailsByName(string Name)
        {
            try
            {
                var product1 = Db.Product.FirstOrDefault(x=>x.Name==Name);
                return product1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Message InsertProductDetail(Product Obj)
        {
            Message Msg = new Message();
            var product =Db.Product.FirstOrDefault(x=>x.Name==Obj.Name);
            var product1 = Db.Product.FirstOrDefault(x => x.ProductId == Obj.ProductId);
            if (product == null && Obj.ProductId==0)
            {
                Db.Product.Add(Obj);
                Db.SaveChanges();              
                Msg.success = true;
                Msg.message = "The product Added succesfully";
                return Msg;
            }

           else if (product != null && product1 != null)
            {
                Msg.success = true;
                Msg.message = "Succsfully Updated";
                Product pro = GetProductDetailsById(Obj.ProductId);
                pro.Name = Obj.Name;
                pro.Price = Obj.Price;
                Db.Update(pro);
                Db.SaveChanges();
            }
            else
            {
                Msg.success = false;
                Msg.message = "The product already Exists";
                return Msg;

            }
              

            return Msg;

        }

        public Message Updateproduct(Product Obj)
        {
            Message msg = new Message();
            msg.success = false;
            Product pro = GetProductDetailsById(Obj.ProductId);
            if (Obj.ProductId != null)
            {
                pro.Name = Obj.Name;
                pro.Price = Obj.Price;
                Db.Update(pro);
                Db.SaveChanges();
                return msg;
            }
            else
            {
                msg.success = false;
                msg.message = "Phone number already exist";
                return msg;
            }
        }

        public Message Deleteproduct(int Id)
        {

            Message Msg = new Message();
            var delete = Db.Product.Find(Id);
            var deleteorder=Db.OrderDetail.FirstOrDefault(x=>x.ProductId==Id);
            if(delete !=null && deleteorder == null)
            {
                Db.Remove(delete);
                Db.SaveChanges();
                Msg.success = true;
                Msg.message = "Product deleted Succesfully";
                return Msg;
            }
            else
            {
                Msg.success = false;
                Msg.message = "The Product order the customer so not removable  "+ delete.Name ;
           
            }
            return Msg;
        }

    }
}

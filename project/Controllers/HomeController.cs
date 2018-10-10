using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectWith中佑.Models;

namespace projectWith中佑.Controllers
{
    
    public class HomeController : Controller
    {
        SlotGameWebEntities2 db = new SlotGameWebEntities2();
        // GET: Home
        public ActionResult Index()
        {
            
            Session["phoneRepeat"] = "";
            Session["nickNameRepeat"] = "";
            Session["passwdNotRepeat"] = "";
            if (Session["userName"].ToString()== "帳號或密碼錯誤") {
                Session["userName"] = "";
            }
          
            Member mem = new Member();
           
            return View(mem);
        }
        //Log in and sign in 
        [HttpPost]
        public ActionResult Index(Member mem,string loginbtn,string memberPassword2)
        {
            if (loginbtn == "登入")
            {
                Session["memberPocketPoints"] = "";
                Session["phoneRepeat"] = "";
                Session["nickNameRepeat"] = "";
                Session["passwdNotRepeat"] = "";
                foreach(var mem2 in db.Members){
                    if (mem.phone == mem2.phone && mem.memberPassword == mem2.memberPassword)
                    {
                        Session["userName"] = mem2.nickName;
                        Session["memberPocketPoints"] = mem2.pocketPoint;
                        Session["memberId"] = mem2.memberId;
                        return RedirectToAction("Index");
                    }
                    Session["userName"] = "帳號或密碼錯誤";
                }
                return View(mem);
            }
            else {
                Session["userName"] = "";
                Session["phoneRepeat"]="";
                Session["nickNameRepeat"] = "";
                Session["passwdNotRepeat"] = "";
                foreach (var mem3 in db.Members) {

                    if (mem.phone == mem3.phone)
                    {
                        Session["phoneRepeat"] = "您的電話已經有人使用";
                    }
                    
                    if (mem.nickName == mem3.nickName)
                    {
                        Session["nickNameRepeat"] = "您的暱稱已經有人使用";
                    }
                    if (mem.memberPassword != memberPassword2)
                    {
                        Session["passwdNotRepeat"] = "密碼重複輸入錯誤";

                    }
                    if (Session["phoneRepeat"].ToString()!=""|| Session["nickNameRepeat"].ToString() != ""|| Session["passwdNotRepeat"].ToString()!="") {
                        return View(mem);
                    }
                 
               }
                //if (mem.memberPassword != memberPassword2)
                //{
                //    Session["passwdNotRepeat"] = "密碼重複輸入錯誤";
                //    return View(mem);
                //}
                mem.pocketPoint = 600;
                db.Members.Add(mem);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


          
        }
        //only fot using on logout
        public ActionResult logOut()
        {
            Session["memberPocketPoints"] = "";
            Session["memberId"] = "";
            Session["userName"] = "";
            //Session.Remove("userName");
            return RedirectToAction("Index");
        }
        //customer server usging signalR
        public ActionResult Serve()
        {
            return View();
        }

        public ActionResult loginProvacy()
        {
            return View();
        }

        //store record , game record,convert record
        public ActionResult member()
        {
            Session["RecordState"] = "1";
            Member mem = db.Members.Find(Session["memberId"]);
            Session["memberPocketPoints"] = mem.pocketPoint;
            var Store = from u in db.Stores
                        where u.memberId == mem.memberId
                        select u;
            var GameRecord = from u in db.GameRecords
                        where u.memberId == mem.memberId
                        select u;
            var memberShopAndProduct = from u in db.MemberShops
                                       join b in db.Products on u.productId equals b.productId
                        where u.memberId == mem.memberId
                        select new memberShopAndProduct1 {
                            productId=u.productId,
                            memberShopID=u.memberShopID,
                            memberId=u.memberId,
                            payState=u.payState,
                            shopNumber=(int)u.shopNumber,
                            shopDate=u.shopDate,
                            productName=b.productName,
                            productPrice=b.productPrice,
                            productImage=b.productImage
                        };

            var model = new memberPage
            {
                Store = Store,
                GameRecord = GameRecord,
                memberShopAndProduct = memberShopAndProduct
            };

            return View( model);
        }
        [HttpPost]
        public ActionResult member(string btnRecord)
        {
            Session["RecordState"] = btnRecord;
         
                Member mem = db.Members.Find(Session["memberId"]);
                var Store = from u in db.Stores
                            where u.memberId == mem.memberId
                            select u;
                var GameRecord = from u in db.GameRecords
                                 where u.memberId == mem.memberId
                                 select u;
                var memberShopAndProduct = from u in db.MemberShops
                                           join b in db.Products on u.productId equals b.productId
                                           where u.memberId == mem.memberId
                                           select new memberShopAndProduct1
                                           {
                                               productId = u.productId,
                                               memberShopID = u.memberShopID,
                                               memberId = u.memberId,
                                               payState = u.payState,
                                               shopNumber = (int)u.shopNumber,
                                               shopDate = u.shopDate,
                                               productName = b.productName,
                                               productPrice = b.productPrice,
                                               productImage = b.productImage
                                           };

                var model = new memberPage
                {
                    Store = Store,
                    GameRecord = GameRecord,
                    memberShopAndProduct = memberShopAndProduct
                };
                return View(model);
          
             
                      
          


        }


        public ActionResult editMemberProfile()
        {
            Member mem = db.Members.Find(Session["memberId"]);


            return View(mem);
        }
        //cam't repeat nickname except own  
        [HttpPost]
        public ActionResult editMemberProfile(Member mem)
        {
            
            Member mem2 = db.Members.Find(mem.memberId);
            MyToolBox.CopyPropertiesTo(mem, mem2);
            foreach (var mem3 in db.Members) {
                if (mem2.memberId != mem3.memberId) {
                    if (mem2.nickName==mem3.nickName) {
                        Session["nickNameRepeat"] = "您的暱稱已經有人使用";
                        return View(mem);
                    }

                } 
            }
            db.SaveChanges();
            Session["userName"] = mem.nickName;
            return RedirectToAction("Member");
            



           
        }
        public ActionResult passwordSet()
        {
            Member mem = db.Members.Find(Session["memberId"]);
            return View(mem);
        }
        [HttpPost]
        public ActionResult passwordSet(Member mem,string newMemberPassword,string newMemberPassword2)
        {
            Member mem2 = db.Members.Find(mem.memberId);
            MyToolBox.CopyPropertiesTo(mem, mem2);
           
            if (mem2.memberPassword== newMemberPassword)
            {
                Session["passwdNotRepeat"] = "新密碼與原密碼相同";
                return View(mem);
                
            }
            if (newMemberPassword2 != newMemberPassword)
            {
                Session["passwdNotRepeat"] = "新密碼重複錯誤";
                return View(mem);

            }
            mem2.memberPassword = newMemberPassword;
            db.SaveChanges();          
            return RedirectToAction("Member");

        }

        public ActionResult bankAccountSet()
        {
            return View();
        }
       //if username=""and error ,user can't play the game
        public ActionResult gameList()
        {
            if(Session["userName"].ToString() == ""|| Session["userName"].ToString() == "帳號或密碼錯誤")
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult slotGame ()
        {
           
            return View();
        }
        public ActionResult storeMoney()
        {
            Session["storeState"] = "";
            if (Session["userName"].ToString() == ""|| Session["userName"].ToString() == "帳號或密碼錯誤")
            {
                return RedirectToAction("Index");
            }
        
            return View();
            
        }
        //hidStoreBtn is using record what the user select the project
        [HttpPost]
        public ActionResult storeMoney(string hidStoreBtn)
        {
            Session["storeState"] = hidStoreBtn;
            return RedirectToAction("bankIn");
        }
        public ActionResult userKnow()
        {
            return View();
        }

        
        public ActionResult bankIn( )
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult bankIn2(int storePoint,string program,string storeMethod,int storeValue)
        {
            Store sto = new Store();
            sto.storePoint = storePoint.ToString();
            sto.storeProgram = program;
            sto.storeMethod = storeMethod;
            sto.storeValue = storeValue.ToString();

            return View(sto);
        }
        [HttpPost]
        public ActionResult bankIn3(Store sto, int storePoint)
        {
            Member mem = db.Members.Find(Session["memberId"]);
            mem.pocketPoint += (int)storePoint;
            Session["memberPocketPoints"] = mem.pocketPoint;
       
            db.Stores.Add(sto);
            db.SaveChanges();

            return View(sto);
        }

        public ActionResult convertProduct()
        {
            Session["errorShop"] = "";
            var query = (from aa in db.Products
                         select aa).ToList();
            
            return View(query);
        }
        //btnRecord is using record what category do user click 
        [HttpPost]
        public ActionResult convertProduct(string btnRecord)
        {

            var query = (from aa in db.Products
                         where aa.productCategory== btnRecord
                         select aa).ToList();

            return View(query);
        }       
        public ActionResult productDetail(int? id)
        {
            
            Product pro = db.Products.Find(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult productDetail(int productId,int shopNumber,int productStore,int id,int totalMoney)
        {
            if (shopNumber!=0&& shopNumber<= productStore) {
            Product product_Strore=db.Products.Find(id);
            product_Strore.productStore -= shopNumber;
            MemberShop memShop = new MemberShop();
            memShop.memberId = (int)Session["memberId"];
            memShop.productId = productId;
            memShop.payState = "未結帳";
            memShop.shopNumber = shopNumber;
            memShop.shopDate = DateTime.Now.ToString("yyyy/MM/dd");
            memShop.memberShopID = DateTime.Now.ToString("yyyyMMdd") + String.Format("{0:00}", Session["memberId"]);
            memShop.totalMoney=totalMoney* shopNumber;
            db.MemberShops.Add(memShop);
            db.SaveChanges(); ;
             return RedirectToAction("convertProduct");
            }
            Session["errorShop"] = "不能為0或大於庫存量";
          ;
            Product pro = db.Products.Find(id);
            return View(pro);
       
        }


        public ActionResult cart()
        {
            var bb = Convert.ToInt32(Session["memberId"]);
            var cart = from aa in db.MemberShops
                        join cc in db.Products on aa.productId equals cc.productId
                        where (aa.memberId == bb & aa.payState == "未結帳")
                        select new cart {
                            productId = aa.productId,
                            productName = cc.productName,
                            productStore = cc.productStore,
                            productPrice = cc.productPrice,
                            productImage = cc.productImage,
                            memberShopID = aa.memberShopID,
                            payState = aa.payState,
                            shopNumber = (int)aa.shopNumber,
                            totalMoney = (int)aa.totalMoney,
                            Shop = aa.Shop
                        };
            //use to Calculate the user totaly spending that the state is equal to 未結帳 
            var aaa = 0;
            var query=from dd in db.MemberShops
                              where (dd.payState == "未結帳" & dd.memberId == bb)
                              select dd;
              foreach (var vv in query)
                    {
                        aaa += (int)vv.totalMoney;
                       
                    };

            var model = new cartAndTotal      {
                cart = cart,
                Total = aaa,
        
                };
            return View(model);
        }
        //delete user product
        public ActionResult deleteCart(int? id)
        {
            MemberShop memsp = db.MemberShops.Find(id);
            db.MemberShops.Remove(memsp);
            Product proaa = db.Products.Find(memsp.productId);
            proaa.productStore += (int)memsp.shopNumber;
       
            db.SaveChanges();
            return RedirectToAction("cart");
        }
        //use to chang shop number and chage product store
        public ActionResult changeProductNumber(int? id,int? shopNumber)
        {
            Session["errorShop"] = "";
            MemberShop memsp = db.MemberShops.Find(id);
            Product product = db.Products.Find(memsp.productId);
           
            product.productStore -= ((int)shopNumber - (int)memsp.shopNumber);
            if (product.productStore>=0)
            {
                memsp.shopNumber = shopNumber;
            memsp.totalMoney = shopNumber * product.productPrice;
            
            db.SaveChanges();
                return RedirectToAction("cart");
            }
            Session["errorShop"] = "庫存不足";
            return RedirectToAction("cart");
        }

        //product check out and minus the user poclet money
        public ActionResult minusMoney()
        {
            var aa2 = Convert.ToInt32(Session["memberId"]);
            var mem = db.Members.Find(Session["memberId"]);
            var aaa = 0;
            var query = from aa in db.MemberShops
                         where (aa.payState == "未結帳" & aa.memberId== aa2)
                         select aa;
            foreach (var bb in  query) {
                    aaa-= (int)bb.totalMoney;
                    bb.payState = "已兌換";
            };

            if (mem.pocketPoint>= -(int)aaa) { 
            mem.pocketPoint += (int)aaa;

            db.SaveChanges();
            return RedirectToAction("bankOut3");
            }
            Session["errorShop"] = "點數不足";
            return RedirectToAction("cart");
        }
        public ActionResult bankOut3()
        {
            Member mem = db.Members.Find(Session["memberId"]);
            Session["memberPocketPoints"] = mem.pocketPoint;
            return View(mem);
        }
        public ActionResult KungFuLong()
        {
            Member mem = db.Members.Find(Session["memberId"]);
            return View(mem);
        }

    }
    public static class MyToolBox
    {

        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            //在衍生類別中覆寫時，使用指定的繫結條件約束，搜尋目前 Type 的屬性。
            // 在衍生類別中覆寫時，使用指定的繫結條件約束，搜尋目前 Type 的屬性。
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (sourceProp.GetValue(source) != null && destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }
            }
        }
    }
}
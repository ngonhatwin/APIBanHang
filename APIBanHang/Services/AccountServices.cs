using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Text;

namespace APIBanHang.Services
{
    public interface IAccountService 
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetById(string id);
        Task Create(Account account);
        Task CreateByModels(MAccount account);
        Task Update(string id, Account account);
        Task EditByModels(string id, MAccount account);
        Task Delete(string id);
        Task<IEnumerable<MAccount>> SearchAllAccountByName(string name);
    }   
    public class AccountServices : IAccountService
    {
        private readonly IRepository<Account> repository_;
        private readonly XyzContext _context;

        public AccountServices(IRepository<Account> repository, XyzContext context) 
        {
           repository_ = repository;
            _context = context;
        }

        public async Task Create(Account account)
        {
             await repository_.Create(account);
        }

        public async Task Delete(string id)
        {
            await repository_.Delete(id);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await repository_.GetAll();
        }

        public async Task<Account> GetById(string id)
        {
            return await repository_.GetById(id);
        }

        public async Task Update(string id, Account account)
        {
            await repository_.Update(id, account);
        }
        public async Task CreateByModels(MAccount account)
        {
            var Account = GenerateNextAccountCode();
            var ac = new Account
            {
                MaAccount = Account,
                UserName = account.UserName,
                Passwords = account.Passwords,
                Email = account.Email,
            };
            _context.Add(ac);
            await _context.SaveChangesAsync();
            
            //Csv helper

            using (var writer = new StreamWriter("C:\\Users\\ngonh\\source\\repos\\APIBanHang\\Csv\\Filtered-Account.csv", true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var acc = new Account
                {
                    MaAccount = Account,
                    UserName = account.UserName,
                    Passwords = account.Passwords,
                    Email = account.Email,
                };

                csv.WriteRecord(acc);
                csv.NextRecord(); // Đặt xuống dòng mới cho mỗi thông tin khách hàng
                await writer.FlushAsync();
            }
        }

        //using transaction 
        //rollback
        private string GenerateNextAccountCode()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var maxAccount = _context.Accounts
                        .OrderByDescending(a => a.MaAccount)
                        .FirstOrDefault();

                    if (maxAccount == null)
                    {
                        return "AC1";
                    }

                    var lastNumber = int.Parse(maxAccount.MaAccount.Substring(2));
                    var nextNumber = lastNumber + 1;

                    // Kiểm tra tồn tại trước khi thêm mới
                    string nextCode;
                    do
                    {
                        lastNumber++;
                        nextCode = "AC" + lastNumber;
                    } while (_context.Accounts.Any(a => a.MaAccount == nextCode));

                    transaction.Commit();
                    return nextCode;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi và rollback transaction 
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task EditByModels(string id, MAccount account)
        {
            //tracking
            IQueryable<Account> query = _context.Accounts;
            var acc = await (from ac in query where ac.MaAccount == id select ac).SingleOrDefaultAsync();
            if (acc != null)
            {
                acc.UserName = account.UserName;
                acc.Passwords = account.Passwords;
                acc.Email = account.Email;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MAccount>> SearchAllAccountByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Enumerable.Empty<MAccount>();
            }
            IQueryable<Account> query = _context.Accounts;
                var ac = await query
                .Where(e => e.UserName.Contains(name))
                .Select(e => new MAccount
                {
                    MaAccount = e.MaAccount,
                    UserName = e.UserName,
                    Email = e.Email,
                    Passwords = e.Passwords,
                })
                .ToListAsync();
            return ac ?? Enumerable.Empty<MAccount>();
        }

        
    }
}

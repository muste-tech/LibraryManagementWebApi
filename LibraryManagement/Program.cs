using LibraryProject.Repositories;
using LibraryProject.Data;
using LibraryProject.Repositories.Interfaces;
using LibraryProject.Repositories.Implementations;
using LibraryProject.Services.Interface;
using LibraryProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔷 DB CONNECTION
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// 🔷 CONTROLLERS
builder.Services.AddControllers();

// 🔷 SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔷 DEPENDENCY INJECTION (REPOSITORY)
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IBorrowRepository, BorrowRepository>();

// 🔷 DEPENDENCY INJECTION (SERVICE)
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IBorrowService, BorrowService>();

var app = builder.Build();

// 🔷 MIDDLEWARE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
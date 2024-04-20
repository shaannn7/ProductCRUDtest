using ProductManager.Dbcontext;
using ProductManager.Mapper;
using ProductManager.Services.CategoryService;
using ProductManager.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DbContextClass>();
builder.Services.AddAutoMapper(typeof(Mapper_PM));
builder.Services.AddScoped<ICategory, CategoryRepostory>();
builder.Services.AddScoped<IProducts,ProductRepostory>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(op =>
{
    op.AddPolicy("ReactPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

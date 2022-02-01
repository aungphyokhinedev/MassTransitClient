// See https://aka.ms/new-console-template for more information
using MassTransit;
using WeatherAPI;

Console.WriteLine("Hello, World!");

var busControl = Bus.Factory.CreateUsingRabbitMq();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                while (true)
                {
                    var serviceAddress = new Uri("rabbitmq://localhost");
                    var client = busControl.CreateRequestClient<GetWeatherForecasts>();

                    var response = await client.GetResponse<WeatherForecasts>(new { });

          
                    Console.WriteLine(response.Message.ToString());
                    
                    string value = await Task.Run(() =>
                    {
                        Console.WriteLine("Enter message (or quit to exit)");
                        Console.Write("> ");
                        return Console.ReadLine();
                    });

                    if("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                   
                }
            }
            finally
            {
                await busControl.StopAsync();
            }
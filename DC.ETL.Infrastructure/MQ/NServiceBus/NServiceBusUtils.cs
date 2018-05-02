using System;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Transport;
using NServiceBus.Persistence;
using NServiceBus.Persistence.Legacy;

namespace DC.ETL.Infrastructure.MQ.NServiceBus
{
    /// <summary>
    /// nservicebus helper.
    /// </summary>
    public class NServiceBusUtils
    {
        private static EndpointConfiguration _endpointConfiguration = null;

        private static IEndpointInstance _endpointInstance = null;

        #region Init

        /// <summary>
        /// program init nservicebus
        /// </summary>
        /// <typeparam name="T">Transport class</typeparam>
        /// <param name="endpointName">endpoint name</param>
        /// <param name="actRouting">
        /// routing config.
        /// <code>
        /// route.RouteToEndpoint(typeof(PlaceOrder), "Sales");// type is message type. "Sales" is other endpoint name.
        /// </code>
        /// </param>
        /// <returns></returns>
        public static async Task Init<T>(string endpointName, string errorQueue = null, Action<RoutingSettings<T>> actRouting = null) where T : TransportDefinition, new()
        {
            //Console.Title = "ClientUI";

            _endpointConfiguration = new EndpointConfiguration(endpointName);
            //// the error queue configuration
            //_endpointConfiguration.SendFailedMessagesTo(errorQueue);

            //_endpointConfiguration.DisableFeature<TimeoutManager>();

            var transport = _endpointConfiguration.UseTransport<T>();

            var routing = transport.Routing();
            if (actRouting!=null) actRouting(routing);
            //routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            _endpointInstance = await Endpoint.Start(_endpointConfiguration)
                .ConfigureAwait(false);

            
        }

        /// <summary>
        /// use msmq init.
        /// </summary>
        /// <remarks>
        /// When using MSMQ as the transport, the error queue configuration must also be specified
        /// Note:
        /// NServiceBus.PerformanceMonitorUsersInstaller Did not attempt to add user 'PV-X00145091\Administrator' to group 'Performance Monitor Users' since the process is not running with elevated privileges. 
        /// 以管理员身份运行命令 "PV-X00145091\Administrator" 为用户名
        /// net localgroup "Performance Monitor Users" "PV-X00145091\Administrator" /add
        /// 
        /// DISM.exe /Online /NoRestart /English /Enable-Feature /all /FeatureName:MSMQ-Server
        /// </remarks>
        /// <param name="endpointName"></param>
        /// <param name="actRouting"></param>
        /// <returns></returns>
        public static async Task InitMSMQ(string endpointName, Action<RoutingSettings<MsmqTransport>> actRouting = null)
        {
            //Console.Title = "ClientUI";

            _endpointConfiguration = new EndpointConfiguration(endpointName);
            // the error queue configuration
            _endpointConfiguration.SendFailedMessagesTo("error");
            //// The selected persistence doesn't have support for timeout storage.
            //_endpointConfiguration.DisableFeature<TimeoutManager>();
            //// The selected persistence doesn't have support for subscription storage.
            //_endpointConfiguration.DisableFeature<MessageDrivenSubscriptions>();
            _endpointConfiguration.EnableInstallers();

            #region ConfigureMsmqPersistenceEndpoint

            var persistence = _endpointConfiguration.UsePersistence<MsmqPersistence, StorageType.Subscriptions>();
            persistence.SubscriptionQueue(endpointName + ".Subscriptions");

            _endpointConfiguration.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();

            #endregion

            var transport = _endpointConfiguration.UseTransport<MsmqTransport>();

            var routing = transport.Routing();
            // routing.RegisterPublisher(typeof(MyEvent), endpointName);
            if (actRouting != null) actRouting(routing);
            // routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            _endpointInstance = await Endpoint.Start(_endpointConfiguration)
                .ConfigureAwait(false);
        }

        #endregion Init


        /// <summary>
        /// Publish the message to subscribers.
        /// </summary>
        /// <returns></returns>
        public static async Task Publish<T>()
        {
            //Trace();
            await _endpointInstance.Publish<T>().ConfigureAwait(false);
            //Trace();
        }

        /// <summary>
        /// Instantiates a message of type T and publishes it.
        /// </summary>
        /// <param name="messageConstructor"></param>
        /// <returns></returns>
        public static async Task Publish<T>(Action<T> messageConstructor)
        {
            Trace(messageConstructor);
            await _endpointInstance.Publish<T>(messageConstructor).ConfigureAwait(false);
            Trace(messageConstructor);
        }

        /// <summary>
        /// Publish the message to subscribers.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task Publish(object message)
        {
            Trace(message);
            await _endpointInstance.Publish(message).ConfigureAwait(false);
            Trace(message);
        }

        /// <summary>
        /// Instantiates a message of T and sends it.
        /// </summary>
        /// <param name="messageConstructor"></param>
        /// <returns></returns>
        public static async Task Send<T>(Action<T> messageConstructor)
        {
            Trace(messageConstructor);
            await _endpointInstance.Send<T>(messageConstructor).ConfigureAwait(false);
            Trace(messageConstructor);
        }

        /// <summary>
        /// Sends the provided message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task Send(object message)
        {
            Trace(message);
            await _endpointInstance.Send(message).ConfigureAwait(false);
            Trace(message);
        }

        /// <summary>
        /// Instantiates a message of type T and sends it to the given destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="messageConstructor"></param>
        /// <returns></returns>
        public static async Task Send<T>(string destination, Action<T> messageConstructor)
        {
            //Trace(destination, messageConstructor);
            await _endpointInstance.Send<T>(destination, messageConstructor).ConfigureAwait(false);
            //Trace(destination, messageConstructor);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task Send(string destination, object message)
        {
            //Trace(destination, message);
            await _endpointInstance.Send(destination, message).ConfigureAwait(false);
            //Trace(destination, message);
        }

        /// <summary>
        /// Instantiates a message of type T and sends it back to the current endpoint.
        /// </summary>
        /// <param name="messageConstructor"></param>
        /// <returns></returns>
        public static async Task SendLocal<T>(Action<T> messageConstructor)
        {
            Trace(messageConstructor);
            await _endpointInstance.SendLocal<T>(messageConstructor).ConfigureAwait(false);
            Trace(messageConstructor);
        }

        /// <summary>
        /// Sends the message back to the current endpoint.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task SendLocal(object message)
        {
            Trace(message);
            await _endpointInstance.SendLocal(message).ConfigureAwait(false);
            Trace(message);
        }

        /// <summary>
        /// Subscribes to receive published messages of type T.  This method is only necessary if you turned off auto-subscribe.
        /// </summary>
        /// <returns></returns>
        public static async Task Subscribe<T>()
        {
            //Trace();
            await _endpointInstance.Subscribe<T>().ConfigureAwait(false);
            //Trace();
        }

        /// <summary>
        /// Subscribes to receive published messages of the specified type.  This method is only necessary if you turned off auto-subscribe.
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static async Task Subscribe(Type messageType)
        {
            Trace(messageType);
            await _endpointInstance.Subscribe(messageType).ConfigureAwait(false);
            Trace(messageType);
        }

        /// <summary>
        /// Unsubscribes from receiving published messages of the specified type.
        /// </summary>
        /// <returns></returns>
        public static async Task Unsubscribe<T>()
        {
            //Trace();
            await _endpointInstance.Unsubscribe<T>().ConfigureAwait(false);
            //Trace();
        }

        /// <summary>
        /// Unsubscribes from receiving published messages of the specified type.
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public static async Task Unsubscribe(Type messageType)
        {
            Trace(messageType);
            await _endpointInstance.Unsubscribe(messageType).ConfigureAwait(false);
            Trace(messageType);
        }
        /// <summary>
        /// TEST use
        /// </summary>
        /// <param name="message"></param>
        [System.Diagnostics.Conditional("DEBUG")]
        private static void Trace(object message)
        {
            Console.WriteLine("threadid:"+Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}

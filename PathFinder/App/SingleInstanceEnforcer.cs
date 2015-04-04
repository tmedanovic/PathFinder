using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;

namespace PathFinder.WinForms.App
{
    /// <summary>
    /// Helper class that allows the first instance to register a CommandLineHandler which can receive the command line arguments of subsequent 
    /// instances.
    /// </summary>
    [Serializable]
    public class SingleInstanceEnforcer : MarshalByRefObject
    {
        private static IpcChannel _mIpcChannel;

        // used to check if this is the only instance running
        private static Mutex _mMutex;

        // some constants to setup the channel between the server (the first) and the client (subsequent) instances
        private const string PORT_NAME = "PathFinder";
        private const string SERVICE_NAME = "PathFinderDelegates";
        private const string SERVICE_URL = "ipc://" + PORT_NAME + "/" + SERVICE_NAME;
        private const string UNIQUE_IDENTIFIER = "4d538358-780f-4fb9-b041-722d62763b7e";

        // signature of the handler
        public delegate void CommandLineDelegate(string[] args);

        /// <summary>
        /// Here we can assign methods that will be called if we receive command line arguments
        /// </summary>
        private static CommandLineDelegate _mCommandLine;

        public static CommandLineDelegate CommandLineHandler
        {
            get { return _mCommandLine; }
            set { _mCommandLine = value; }
        }

        /// <summary>
        /// Checks if this is the first instance. If it is it does also register the CommandLineDelegate
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool IsFirst(CommandLineDelegate r)
        {
            if (IsFirst())
            {
                CommandLineHandler += r;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Does just check if this is the first instance. If you want to receive command line arguments from other instances you still need
        /// to register a CommandLineHandler
        /// </summary>
        /// <returns></returns>
        public static bool IsFirst()
        {
            _mMutex = new Mutex(false, UNIQUE_IDENTIFIER);

            if (_mMutex.WaitOne(1, true))
            {
                //We locked it! We are the first instance
                CreateInstanceChannel();
                return true;
            }

            //Not the first instance
            _mMutex.Close();
            _mMutex = null;
            return false;
        }

        /// <summary>
        /// Registers the channel for the server
        /// </summary>
        private static void CreateInstanceChannel()
        {
            // correct serialization of delegates
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider
                                                           {
                                                               TypeFilterLevel =
                                                                   System.Runtime.Serialization.Formatters
                                                                   .TypeFilterLevel.Full
                                                           };

            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();

            // Create and register the channel
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties["portName"] = PORT_NAME;
            _mIpcChannel = new IpcChannel(properties, clientProv, serverProv);

            ChannelServices.RegisterChannel(_mIpcChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof (SingleInstanceEnforcer),
                SERVICE_NAME,
                WellKnownObjectMode.SingleCall);
        }

        /// <summary>
        /// Cleanup all used resources. Can be called from the server or from a client
        /// </summary>
        public static void Cleanup()
        {
            if (_mMutex != null)
            {
                _mMutex.Close();
            }

            if (_mIpcChannel != null)
            {
                _mIpcChannel.StopListening(null);
            }

            _mMutex = null;
            _mIpcChannel = null;
        }

        /// <summary>
        /// A client (subsequent) instance can send its Command Line parameter to the first instance (server)
        /// This method might throw an exception for various reasons (could not register the channel, object was not in channel, ...)
        /// </summary>
        /// <param name="s"></param>
        public static void PassCommandLine(string[] s)
        {
            IpcChannel channel = new IpcChannel("PathFinder_Client");
            ChannelServices.RegisterChannel(channel, false);
            SingleInstanceEnforcer ctrl =
                (SingleInstanceEnforcer) Activator.GetObject(typeof (SingleInstanceEnforcer), SERVICE_URL);
            ctrl.ReceiveCommandLine(s);
        }

        /// <summary>
        /// Needs to be public because otherwise it cannot be called remotely!
        /// </summary>
        /// <param name="s"></param>
        public void ReceiveCommandLine(string[] s)
        {
            if (_mCommandLine != null)
            {
                _mCommandLine(s);
            }
        }
    }
}

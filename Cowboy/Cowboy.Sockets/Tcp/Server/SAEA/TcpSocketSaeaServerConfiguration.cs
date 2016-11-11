﻿using System;
using System.Net.Sockets;
using Cowboy.Buffer;

namespace Cowboy.Sockets
{
    public sealed class TcpSocketSaeaServerConfiguration
    {
        public TcpSocketSaeaServerConfiguration()
        {
            BufferManager = new SegmentBufferManager(1024, 8192, 1, true);
            ReceiveBufferSize = 8192;
            SendBufferSize = 8192;
            ReceiveTimeout = TimeSpan.Zero;
            SendTimeout = TimeSpan.Zero;
            NoDelay = true;
            LingerState = new LingerOption(false, 0); // The socket will linger for x seconds after Socket.Close is called.
            KeepAlive = true;
            KeepAliveInterval = TimeSpan.FromSeconds(5);

            PendingConnectionBacklog = 200;
            AllowNatTraversal = true;

            FrameBuilder = new LengthPrefixedFrameBuilder();
        }

        public ISegmentBufferManager BufferManager { get; set; }
        public int ReceiveBufferSize { get; set; }
        public int SendBufferSize { get; set; }
        public TimeSpan ReceiveTimeout { get; set; }
        public TimeSpan SendTimeout { get; set; }
        public bool NoDelay { get; set; }
        public LingerOption LingerState { get; set; }
        public bool KeepAlive { get; set; }
        public TimeSpan KeepAliveInterval { get; set; }

        public int PendingConnectionBacklog { get; set; }
        public bool AllowNatTraversal { get; set; }

        public IFrameBuilder FrameBuilder { get; set; }
    }
}

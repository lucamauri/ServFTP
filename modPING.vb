Imports System.Net
Imports System.Net.Sockets

Module modPING

    Class Pinger
        Const SockError = -1
        Const ICMPEcho = 8


        Public Function GetPINGTime(ByVal Host As String)
            Try
                Dim PingTime As Integer = 0

                Dim ServerHE, FromHE As IPHostEntry
                Dim nBytes As Integer = 0
                Dim dwStart As Integer = 0
                Dim dwStop As Integer = 0

                Dim Packet As New IcmpPacket()

                If Host Is Nothing Then
                    Return -1
                End If

                Dim MainSock As New Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp)

                ServerHE = Dns.GetHostByName(Host)

                If ServerHE Is Nothing Then
                    Return -1
                End If

                Dim IPEPServer As New IPEndPoint(ServerHE.AddressList(0), 0)
                Dim EPServer As EndPoint = IPEPServer

                FromHE = Dns.GetHostByName(Dns.GetHostName())
                Dim IPEndPointFrom As New IPEndPoint(FromHE.AddressList(0), 0)
                Dim EndPointFrom = IPEndPointFrom

                Dim PacketSize As Integer = 0

                Dim j As Integer

                j = 0
                Do While j < 1

                    Packet.Type = ICMPEcho
                    Packet.SubCode = 0
                    Packet.CheckSum = Int16.Parse("0")
                    Packet.Identifier = Int16.Parse("45")
                    Packet.SequenceNumber = Int16.Parse("0")

                    Dim PingData As Integer = 32

                    'dim Packet.Data as Byte(PingData)
                    ReDim Packet.Data(PingData)

                    Dim i As Integer
                    For i = 0 To PingData
                        Packet.Data(i) = Convert.ToByte(Convert.ToChar(35))
                    Next

                    PacketSize = PingData + 8

                    If PacketSize Mod 2 = 1 Then
                        PacketSize += 1
                    End If

                    Dim ICMPPktBuffer As Byte()
                    ReDim ICMPPktBuffer(PacketSize)

                    Dim Index As Int32 = 0

                    Index = Serialize(Packet, ICMPPktBuffer, PacketSize, PingData)

                    If Index = -1 Then
                        Return -1
                    End If

                    Dim DoubleLength As Double = Convert.ToDouble(Index)

                    Dim dTemp As Double = Math.Ceiling(DoubleLength / 2)

                    Dim ChkSumBufferLength As Integer = Convert.ToInt32(dTemp)

                    Dim ChkSumBuffer As Int16()
                    ReDim ChkSumBuffer(ChkSumBufferLength)

                    Dim ICMPHeaderBufferIndex As Integer = 0

                    For i = 0 To ChkSumBufferLength
                        ChkSumBuffer(i) = BitConverter.ToInt16(ICMPPktBuffer, ICMPHeaderBufferIndex)
                        ICMPHeaderBufferIndex += 2
                    Next i

                    Dim uChkSum As Int16 = CheckSum(ChkSumBuffer, ChkSumBufferLength)
                    Packet.CheckSum = uChkSum

                    Dim SendBuf As Byte()
                    ReDim SendBuf(PacketSize)

                    Index = Serialize(Packet, SendBuf, PacketSize, PingData)

                    If Index = -1 Then
                        Return -1
                    End If

                    dwStart = System.Environment.TickCount

                    If (nBytes = MainSock.SendTo(SendBuf, PacketSize, 0, EPServer)) = SockError Then
                        Console.WriteLine("Error calling sendto")
                        Return -1
                    End If

                    Dim ReceiveBuffer As Byte()
                    ReDim ReceiveBuffer(256)

                    nBytes = 0
                    nBytes = MainSock.ReceiveFrom(ReceiveBuffer, 256, 0, EndPointFrom)

                    If nBytes = SockError Then
                        dwStop = SockError
                    Else
                        dwStop = System.Environment.TickCount - dwStart
                    End If
                    j += 1
                Loop

                MainSock.Close()
                PingTime = Convert.ToInt16(dwStop)
                Return PingTime

            Catch exc As Exception
                MessageBox.Show(exc.ToString)
            End Try

        End Function

        Public Function Serialize(ByVal packet As IcmpPacket, ByVal Buffer As Byte(), ByVal PacketSize As Int32, ByVal PingData As Int32) As Int32

            Dim cbReturn As Int32 = 0

            Dim Index As Int32 = 0

            Dim bType As Byte()
            ReDim bType(0)
            bType(0) = packet.Type

            Dim bCode As Byte()
            ReDim bCode(0)
            bCode(0) = packet.SubCode

            Dim bChkSum As Byte() = BitConverter.GetBytes(packet.CheckSum)
            Dim bID As Byte() = BitConverter.GetBytes(packet.Identifier)
            Dim bSeq As Byte() = BitConverter.GetBytes(packet.SequenceNumber)

            Try

                ReDim Buffer(bType.Length + bCode.Length + bChkSum.Length + bID.Length + bSeq.Length)

                Array.Copy(bType, 0, Buffer, Index, bType.Length)
                Index += bType.Length

                'Console.WriteLine("Serialize code ");
                Array.Copy(bCode, 0, Buffer, Index, bCode.Length)
                Index += bCode.Length

                'Console.WriteLine("Serialize cksum ");
                Array.Copy(bChkSum, 0, Buffer, Index, bChkSum.Length)
                Index += bChkSum.Length

                'Console.WriteLine("Serialize id ");
                Array.Copy(bID, 0, Buffer, Index, bID.Length)
                Index += bID.Length

                Array.Copy(bSeq, 0, Buffer, Index, bSeq.Length)
                Index += bSeq.Length

                'copy the data

                Array.Copy(packet.Data, 0, Buffer, Index, PingData)

            Catch exc As Exception
                MessageBox.Show(exc.ToString)
            End Try

            Index += PingData

            If Not (Index = PacketSize) Then
                cbReturn = -1
                Return cbReturn
            End If

            cbReturn = Index
            Return cbReturn


        End Function

        Public Function CheckSum(ByVal Buffer As Int16(), ByVal Size As Integer) As Int16

            Dim ChkSum As Int32 = 0
            Dim Counter As Integer

            Counter = 0

            Do While (Size > 0)

                Dim val As Int16 = Buffer(Counter)

                ChkSum += Convert.ToInt32(Buffer(Counter))
                Counter += 1
                Size -= 1
            Loop

            ChkSum = RightShift(ChkSum, 16) + (ChkSum And &HFFFF)
            ChkSum += RightShift(ChkSum, 16)

            Return Convert.ToInt16(Not (ChkSum))

        End Function

        Function RightShift(ByVal Value As Long, ByVal Pos As Long) As Long

            Return (Value \ (2 ^ Pos))

        End Function

        Function LeftShift(ByVal Value As Long, ByVal Pos As Long) As Long

            Return (Value * (2 ^ Pos))

        End Function
    End Class

    Public Class IcmpPacket

        Public Type As Byte
        Public SubCode As Byte
        Public CheckSum As Int16
        Public Identifier As Int16
        Public SequenceNumber As Int16
        Public Data As Byte()

    End Class
End Module

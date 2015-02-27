using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Decorate
{
    class Program
    {
        private static void Main(string[] args)
        {

            using (FileStream fs = new FileStream(@"c:\temp\test.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                DuplicatingFileStream dupFStream = new DuplicatingFileStream(fs);
                XoringFileStrweam xorFStream = new XoringFileStrweam(dupFStream);
                StreamWriter sw = new StreamWriter(xorFStream);
                sw.WriteLine("Hello wordl");
                sw.Flush();
            }

            // compiled ==
            // FileStream fs = new FileStream(@"c:\temp\test.txt", FileAccess.Write, FileMode.Create);
            //try
            //{
            //}
            //finally
            //{
            //    fs.Dispose();
            //}

        }
    }


    public abstract class StreamDecorator : Stream
    {
        private Stream _original;

        public StreamDecorator(Stream original)
        {
            _original = original;
        }

        public override bool CanRead
        {
            get { return _original.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _original.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _original.CanWrite; }
        }

        public override void Flush()
        {
            _original.Flush();
        }

        public override long Length
        {
            get { return _original.Length; }
        }

        public override long Position
        {
            get { return _original.Position; }
            set { _original.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _original.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _original.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _original.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _original.Write(buffer, offset, count);
        }
    }

    public class XoringFileStrweam : StreamDecorator
    {
        public XoringFileStrweam(Stream original) : base(original)
        {
            
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            for (int x = 1; x < count; x++)
            {
                buffer[offset + x] = (byte) (buffer[offset + x] ^ 0xAB);
            }

            base.Write(buffer, offset, count);
        }
    }

    public class DuplicatingFileStream : StreamDecorator
    {
        public DuplicatingFileStream(Stream original) : base(original)
        {
        }


        public override void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
            base.Write(buffer, offset, count);
        }
    }

    public abstract class MortgageCalculator
    {
        public double Calculate(IOutputStrategy handler)
        {
            handler.output(String.Format("Result: {0}", someValue + someValue2 * someValue3 / someValue4));
        }

        protected abstract int someValue { get; }
        protected abstract int someValue2 { get; }
        protected abstract int someValue3 { get; }
        protected abstract int someValue4 { get; }
    }

    publiv

    public interface IOutputStrategy
    {
        void output(string outstr);
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnowSharp;
using SnowSharp.GameObjects;
using System;


namespace OnWindows.Tests
{
    [TestClass()]
    public class DataActorTests
    {
        GameWindow win = GameWindow.PrepTestWindow();

        class TestOutputerDouble : GameObjectList
        {
            DataActor<double> dt = new DataActor<double>(SnowSharp.Math.Mixers.DoubleMixer);
            public TestOutputerDouble()
            {
                dt.Function = SnowSharp.Math.Funcs.Twice;
                dt.Begin(0, 100, 60);
                Add(dt);
            }
            public override void OnUpdate()
            {
                base.OnUpdate();

                Console.WriteLine(dt.Value);
                if (dt.Died) Core.Exit();
            }
        }

        [TestMethod()]
        public void DoubleDataActor()
        {
            Core.Objects.Add(new TestOutputerDouble());
            win.Run();
        }

        class TestOutputerVector2d : GameObjectList
        {
            DataActor<OpenTK.Vector2d> dt = new DataActor<OpenTK.Vector2d>(SnowSharp.Math.Mixers.Vector2dMixer);
            public TestOutputerVector2d()
            {
                dt.Function = SnowSharp.Math.Funcs.Twice;
                dt.Begin(new OpenTK.Vector2d(0,0), new OpenTK.Vector2d(-100, 100), 60);
                Add(dt);
            }
            public override void OnUpdate()
            {
                base.OnUpdate();

                Console.WriteLine(dt.Value);
                if (dt.Died) Core.Exit();
            }
        }

        [TestMethod()]
        public void Vector2dDataActor()
        {
            Core.Objects.Add(new TestOutputerVector2d());
            win.Run();
        }
    }
}


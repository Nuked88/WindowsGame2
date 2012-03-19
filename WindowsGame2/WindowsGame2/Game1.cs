using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;

namespace WindowsGame2
{
    /// <summary>
    /// Questo è il tipo principale per il gioco
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Creates a new World with Gravity of 10 in downward direction.
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Consente al gioco di eseguire tutte le operazioni di inizializzazione necessarie prima di iniziare l'esecuzione.
        /// È possibile richiedere qualunque servizio necessario e caricare eventuali
        /// contenuti non grafici correlati. Quando si chiama base.Initialize, tutti i componenti vengono enumerati
        /// e inizializzati.
        /// </summary>
        /// 
        Texture2D MyTexture;
        World MyWorld;
        Body BoxBody, FloorBody;
        protected override void Initialize()
        {
            // TODO: aggiungere qui la logica di inizializzazione

            base.Initialize();
        }

        /// <summary>
        /// LoadContent verrà chiamato una volta per gioco e costituisce il punto in cui caricare
        /// tutto il contenuto.
        /// </summary>
        protected override void LoadContent()
        {
            World MyWorld = new World(-Vector2.UnitY * 10);
            // Creare un nuovo SpriteBatch, che potrà essere utilizzato per disegnare trame.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Create Floor
            Fixture floorFixture = FixtureFactory.CreateRectangle(MyWorld, ConvertUnits.ToSimUnits(480), ConvertUnits.ToSimUnits(10), 10);
            floorFixture.Restitution = 0.5f;        //Bounceability
            floorFixture.Friction = 0.5f;           //Friction
            FloorBody = floorFixture.Body;          //Get Body from Fixture
            FloorBody.IsStatic = true;              //Floor must be stationary object

            //Create Box, (Note:Different way from above code, just to show it otherwise there is no difference)
            BoxBody = BodyFactory.CreateBody(MyWorld);
            FixtureFactory.CreateRectangle(ConvertUnits.ToSimUnits(50), ConvertUnits.ToSimUnits(50), 10, Vector2.Zero, BoxBody);
            foreach (Fixture fixture in BoxBody.FixtureList)
            {
                fixture.Restitution = 0.5f;
                fixture.Friction = 0.5f;
            }
            BoxBody.BodyType = BodyType.Dynamic;

            //Place floor object to bottom of the screen.
            FloorBody.Position = ConvertUnits.ToSimUnits(new Vector2(240, 700));

            //Place Box on screen, somewhere
            BoxBody.Position = ConvertUnits.ToSimUnits(new Vector2(240, 25));
            // TODO: utilizzare this.content per caricare qui il contenuto del gioco
        }

        /// <summary>
        /// UnloadContent verrà chiamato una volta per gioco e costituisce il punto in cui scaricare
        /// tutto il contenuto.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: scaricare qui tutto il contenuto non gestito da ContentManager
        }

        /// <summary>
        /// Consente al gioco di eseguire la logica per, ad esempio, aggiornare il mondo,
        /// controllare l'esistenza di conflitti, raccogliere l'input e riprodurre l'audio.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Update(GameTime gameTime)
        {
            // Consente di uscire dal gioco
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: aggiungere qui la logica di aggiornamento

            base.Update(gameTime);
        }

        /// <summary>
        /// Viene chiamato quando il gioco deve disegnarsi.
        /// </summary>
        /// <param name="gameTime">Fornisce uno snapshot dei valori di temporizzazione.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: aggiungere qui il codice di disegno

            base.Draw(gameTime);
        }
    }
}

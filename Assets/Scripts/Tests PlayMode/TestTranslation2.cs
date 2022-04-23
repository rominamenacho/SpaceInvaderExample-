using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestTranslation2
    {
        GameObject go;
        Rigidbody2D rb;
        Translator trans;
        Vector3 oldPos;

        [SetUp]
        public void Setup()
        {
            go = new GameObject();
            rb = go.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            trans = go.AddComponent<Translator>();
            oldPos = go.transform.position;
        }
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GivenZeroMovementVectorTeGameObjectStayInPLace()
        {

            yield return null;

            trans.Move(Vector2.zero);

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(1f);

            Assert.AreEqual(oldPos, go.transform.position);
        }


        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesToAsExpected()
        {


            yield return null;

            trans.Move(Vector2.right);

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(oldPos.y, go.transform.position.y);
            Assert.IsTrue(Mathf.Approximately(1f, go.transform.position.x), "transform.position.x is not 1f as expected");

        }
    }
}

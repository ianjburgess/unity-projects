using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { room, mirror, sheets_0, lock_0, room_mirror, sheets_1, lock_1, freedom };
    private States myState;
    

	// Use this for initialization
	void Start () {
        myState = States.room;
	}

    // Update is called once per frame
    void Update() {
        print(myState);
        if (myState == States.room)                 {state_room();}
        else if (myState == States.sheets_0)        {state_sheets_0();}
        else if (myState == States.room_mirror)     {state_room_mirror();}
        else if (myState == States.lock_0)          {state_lock_0();}
        else if (myState == States.mirror)          {state_mirror();}
        else if (myState == States.sheets_1)        {state_sheets_1();}
        else if (myState == States.lock_1)          {state_lock_1();}
        else if (myState == States.freedom)         {state_freedom();}
	}

    #region Sate handler methods
    void state_room () {
        text.text = "You are locked in a small room, and you want to escape. There are " +
            "some dirty sheets on the bed, a mirror on the wall, and the door " +
            "is locked from the outside.\n\n" +
            "Press S to view Sheets, M to view Mirror and L to view Lock.";

        if (Input.GetKeyDown(KeyCode.S))                {myState = States.sheets_0;}
        else if (Input.GetKeyDown(KeyCode.M))           {myState = States.room_mirror;}
        else if (Input.GetKeyDown(KeyCode.L))           {myState = States.lock_0;}
    }

    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
            "time somebody changed them.\n\n" +
            "Press BACK SPACE to return to roaming the room.";

        if (Input.GetKeyDown(KeyCode.Backspace))        {myState = States.room;}
    }

    void state_sheets_1()
    {
        text.text = "Still the same dirty old sheets." +
            "Press BACK SPACE to return to roaming the room.";

        if (Input.GetKeyDown(KeyCode.Backspace))        {myState = States.room_mirror;}
    }

    void state_mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
            "Press T to Take the mirror, or BACK SPACE to return to roaming the room.";

        if (Input.GetKeyDown(KeyCode.Backspace))        {myState = States.room;}
        else if (Input.GetKeyDown(KeyCode.T))           {myState = States.room_mirror;}
    }

    void state_room_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
            "some dirty sheets on the bed, a mark where the mirror was, " +
            "and that pesky door is still there, and firmly locked!\n\n" +
            "Press S to view Sheets or L to view Lock";

        if (Input.GetKeyDown(KeyCode.S))                {myState = States.sheets_1;}
        else if (Input.GetKeyDown(KeyCode.L))           {myState = States.lock_1;} 
    }

    void state_lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
            "combination is. You wish you could somehow see where the dirty " +
            "fingerprints were, maybe that would help.\n\n" +
            "Press BACK SPACE to Return to roaming your cell";

        if (Input.GetKeyDown(KeyCode.Backspace))        {myState = States.room;}
    }

    void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
            "so you can see the lock. You can just make out fingerprints around " +
            "the buttons. You press the dirty buttons, and hear a click.\n\n" +
            "Press O to Open or BACK SPACE to return to roaming your room.";

        if (Input.GetKeyDown(KeyCode.Backspace))        {myState = States.room_mirror;}
        else if (Input.GetKeyDown(KeyCode.O))           {myState = States.freedom;}
    }

    void state_freedom()
    {
        text.text = "You finally escape only to find a zombie apocolypse has started. GG!";
    }
    #endregion
}

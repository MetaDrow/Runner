interface IMove 
{
   float _speed { set; get; }

    void MoveForward(float _speed);

    void MoveRight(ref int _line);

    void MoveLeft( ref int _line);

}

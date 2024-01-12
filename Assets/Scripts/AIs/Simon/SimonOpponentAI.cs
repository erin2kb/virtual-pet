using System;

public class SimonOpponentAI : AIOpponent
{
    // Class variables
    private SimonInput[] _sequence;
    private int _chunkLength;
    private int _numChunks;
    private System.Random _random;
    private int _currentChunk;

    // Properties
    public bool IsFinished { get; private set; }

    // Constructors
    public SimonOpponentAI(int sequenceChunkLength, int numSequenceChunks)
    {
        _random = new Random();
        _chunkLength = sequenceChunkLength;
        _numChunks = numSequenceChunks;
        _sequence = RandomizeSequence();
        _currentChunk = 1;
        IsFinished = false;
    }

    public SimonOpponentAI(int sequenceChunkLength, SimonInput[] sequence)
    {
        _chunkLength = sequenceChunkLength;
        _numChunks = sequence.Length / sequenceChunkLength;
        _sequence = sequence;
        _currentChunk = 1;
        IsFinished = false;
    }

    // Functions
    private SimonInput[] RandomizeSequence()
    {
        SimonInput[] sequence = new SimonInput[_chunkLength * _numChunks];
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = GetRandomInput();
        }
        return sequence;
    }

    private SimonInput GetRandomInput()
    {
        return (SimonInput)Enum.ToObject(typeof(SimonInput), _random.Next(4));
    }

    public SimonInput[] Play()
    {
        int currentSequenceLength = _chunkLength * _currentChunk;
        SimonInput[] currentSequence = new SimonInput[currentSequenceLength];
        Array.Copy(_sequence, 0, currentSequence, 0, currentSequenceLength);
        if (_currentChunk >= _numChunks)
        {
            IsFinished = true;
        }
        else
        {
            _currentChunk++;
        }
        return currentSequence;
    }

    public override string ToString()
    {
        return $"chunk length of {_chunkLength} and sequence of {String.Join(" ", _sequence)}";
    }
}
using MinECS;

public class UpdateEngien
{
    private TranslationSystem _translationSystem;
    private PlayerInputSystem _playerInputSystem;

    public UpdateEngien()
    {
        _translationSystem = new TranslationSystem();
        _playerInputSystem = new PlayerInputSystem();   
    }

    public void Update(double delta)
    {
        _playerInputSystem.Update(delta);   
        _translationSystem.Update(delta);
    }
}


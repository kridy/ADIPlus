using MinECS;

public class UpdateEngien
{
    private TranslationSystem _translationSystem;
    private PlayerInputSystem _playerInputSystem;
    private CollisionDetectionSystem _collisionDetectionSystem;
    private CollisionResolverSystem _collisionResolveSystem;
    public UpdateEngien()
    {
        _translationSystem = new TranslationSystem();
        _playerInputSystem = new PlayerInputSystem();
        _collisionDetectionSystem = new CollisionDetectionSystem();
        _collisionResolveSystem = new CollisionResolverSystem();
    }

    public void Update(double delta)
    {
        _playerInputSystem.Update(delta);   
        _translationSystem.Update(delta);
        _collisionDetectionSystem.Update(delta);
        _collisionResolveSystem.Update(delta);
    }
}


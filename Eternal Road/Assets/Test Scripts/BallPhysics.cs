//Final Round: Eternal Road
//Last Editor: Manu Moral

using UnityEngine;

namespace Unity3DMiniGames
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]

    public class BallPhysics : MonoBehaviour
    {
        Rigidbody rb;
        SphereCollider spherCol;
        [SerializeField] PhysicMaterial _gum, _offGum, _stone, _plasti, _balloon;
        [SerializeField] MeshRenderer _ballSprite;
        [SerializeField] Material _gumSprite, _stoneSprite, _plastiSprite, _balloonSprite;
        [SerializeField] GameObject _stoneCanvas;
        [SerializeField] HUDDisplay _hud;
        [SerializeField] float _jumpForce, _startFlyForce, _flyForce, _rushSpeed;
        [SerializeField] int _stoneDurability;
        [SerializeField] Vector3  _spriteNormalBallSize, _spriteSmallBallSize;
        [SerializeField] ContinousRotation _roadRot;
        [SerializeField] LaneChange _laneChange;
        [SerializeField] bool _isGum, _isStone, _isBalloon, _isPlasti;
        bool isJump, isReSized, isFly, isRush, isGrounded, isOutOfControl, isJumping, isGroundOnLeft,
            isGroundOnRight, isWallOnRight, isWallOnLeft, isSmallPlasti;
        int startDurability;

        #region Public References

        public bool IsGroundOnLeft { get => isGroundOnLeft; set { isGroundOnLeft = value; } }
        public bool IsGroundOnRight { get => isGroundOnRight; set { isGroundOnRight = value; } }
        public bool IsWallOnRight { get => isWallOnRight; set { isWallOnRight = value; } }
        public bool IsWallOnLeft { get => isWallOnLeft; set { isWallOnLeft = value; } }

        public bool IsGum { get => _isGum; }
        public bool IsStone { get => _isStone; }
        public bool IsPlasti { get => _isPlasti; }
        public bool IsBalloon { get => _isBalloon; }
        public bool IsGrounded { get => isGrounded; }
        public bool IsOutOfControl { get => isOutOfControl; }
        public bool IsSmallPlasti { get => isSmallPlasti; }
        public bool IsRush { get => isRush; }

        #endregion

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            spherCol = GetComponent<SphereCollider>();
        }

        private void Start()
        {
            ChangeMaterial(0);
            startDurability = _stoneDurability;
        }

        private void Update()
        {
            ReadInput();
        }

        private void FixedUpdate()
        {
            Jump();
            ReSize();
            Fly();
        }

        public void LostDurability(int points)
        {
            _stoneDurability -= points;
            _stoneCanvas.GetComponent<StoneDurabilityCanvas>().DisplayDurability(_stoneDurability);
            if (_stoneDurability <= 0) StoneCrash();
        }

        public void GumOutOfControl()
        {
            isOutOfControl = true;
            rb.mass = .5f;
            spherCol.material = _offGum;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.AddForce(Vector3.left * _jumpForce, ForceMode.Impulse);
            Invoke(nameof(GameOver), 0.25f);
        }

        public void CrashOnWall()
        {
            isOutOfControl = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke(nameof(GameOver), 0.1f); //Game Over by Crash on Wall
        }

        public void StoneCrash()
        {
            isOutOfControl = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            _stoneCanvas.SetActive(false);
            Invoke(nameof(GameOver), 0.1f); //Game Over by Crash on Wall
        }

        void ReadInput()
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                if (_isGum && isGrounded && !isOutOfControl && !isJumping)
                {
                    isJump = true;
                    isJumping = true;
                }
                
                if (_isPlasti && !isOutOfControl)
                {
                    isReSized = true;
                }

                if (_isBalloon && !isOutOfControl)
                {
                    isFly = true;
                }
            }  

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                if (_isStone && !isOutOfControl && isGrounded && !isRush)
                {
                    _roadRot.RotSpeed = _rushSpeed;
                    Invoke(nameof(EndOfRush), 0.2f);
                    isRush = true;
                }
            }

            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                if (_isPlasti && !isOutOfControl)
                {
                    isReSized = false;
                }
            }
        }

        void Jump()
        {
            if (isJump)
            {
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                isJump = false;
            }
        }

        void ReSize()
        {
            if (isReSized)
            {
                isSmallPlasti = true;
                //Changes in the Physics:
                spherCol.radius = .15f;
                rb.mass = .5f;
                //Changes in Appearance:
                _ballSprite.gameObject.transform.localScale = _spriteSmallBallSize;
            }
            else
            {
                isSmallPlasti = false;
                //Changes in the Physics:
                spherCol.radius = .3f;
                rb.mass = 2f;
                //Changes in Appearance:
                _ballSprite.gameObject.transform.localScale = _spriteNormalBallSize;
            }

        }

        void Fly()
        {
            if (isFly)
            {
                rb.AddForce(Vector3.up * _flyForce, ForceMode.Impulse);
                isFly = false;
            }
        }

        void EndOfRush()
        {
            _roadRot.ResetSpeed();
            isRush = false;
        }

        void ChangeMaterial(int id)
        {
            switch (id)
            {
                case 0: //GUM
                    _isGum = true;
                    _isStone = false;
                    _isPlasti = false;
                    _isBalloon = false;

                    //Set Gum Properties:
                    transform.tag = "Gum";
                    rb.mass = 1.5f;
                    rb.drag = 0f;
                    rb.angularDrag = 0f;
                    spherCol.material = _gum;
                    _ballSprite.material = _gumSprite;
                    _laneChange.ChangeLaneDuration = 0.5f;
                    _stoneCanvas.SetActive(false);
                    _hud.DisplaySkillBTN(0);

                    break;

                case 1: //STONE
                    _isGum = false;
                    _isStone = true;
                    _isPlasti = false;
                    _isBalloon = false;

                    //Set Stone Properties
                    transform.tag = "Stone";
                    rb.mass = 3f;
                    rb.drag = 0f;
                    rb.angularDrag = 0f;
                    spherCol.material = _stone;
                    _ballSprite.material = _stoneSprite;
                    _laneChange.ChangeLaneDuration = 1f;
                    _stoneDurability = startDurability;
                    _stoneCanvas.SetActive(true);
                    _stoneCanvas.GetComponent<StoneDurabilityCanvas>().DisplayDurability(_stoneDurability);
                    _hud.DisplaySkillBTN(1);

                    break;

                case 2: //PLASTICINE
                    _isGum = false;
                    _isStone = false;
                    _isPlasti = true;
                    _isBalloon = false;

                    //Set Plasticine Properties
                    transform.tag = "Plasticine";
                    rb.mass = 2f;
                    rb.drag = 0f;
                    rb.angularDrag = 0f;
                    spherCol.material = _plasti;
                    _ballSprite.material = _plastiSprite;
                    _laneChange.ChangeLaneDuration = 0.75f;
                    _stoneCanvas.SetActive(false);
                    _hud.DisplaySkillBTN(2);

                    break;

                case 3: //BALLOON
                    _isGum = false;
                    _isStone = false;
                    _isPlasti = false;
                    _isBalloon = true;

                    //Set Balloon Properties
                    transform.tag = "Balloon";
                    rb.mass = .01f;
                    rb.drag = .5f;
                    rb.angularDrag = .5f;
                    spherCol.material = _balloon;
                    _ballSprite.material = _balloonSprite;
                    _laneChange.ChangeLaneDuration = 0.25f;
                    rb.AddForce(Vector3.up * _startFlyForce, ForceMode.Force);
                    _stoneCanvas.SetActive(false);
                    _hud.DisplaySkillBTN(3);

                    break;
            }
        }

        void GameOver()
        {
            _roadRot.OnGameOver = true; 
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
                isJumping = false;
            }
            else if (col.gameObject.CompareTag("Abyss"))
            {
                isGrounded = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                Invoke(nameof(GameOver), 0.1f); //Game Over by Fall in Abyss
            }

        }

        private void OnCollisionStay(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                isGrounded = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Gum_PU"))
            {
                if (!_isGum) ChangeMaterial(0);
                Destroy(other.gameObject, 0.1f);
            }
            else if (other.CompareTag("Stone_PU"))
            {
                if (!_isStone) ChangeMaterial(1);
                Destroy(other.gameObject, 0.1f);
            }
            else if (other.CompareTag("Plasticine_PU"))
            {
                if (!_isPlasti) ChangeMaterial(2);
                Destroy(other.gameObject, 0.1f);
            }
            else if (other.CompareTag("Balloon_PU"))
            {
                if (!_isBalloon) ChangeMaterial(3);
                Destroy(other.gameObject, 0.1f);
            }
        }
    }
}

import os

class Config:
    FLASK_ENV = os.getenv("FLASK_ENV", "production")
    MODEL_PATH = os.getenv("MODEL_PATH", "models/modelo.pkl")

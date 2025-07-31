from flask import Flask
from flask_cors import CORS
from dotenv import load_dotenv

def create_app():
    load_dotenv()

    app = Flask(__name__)

    # Configuración general
    app.config.from_object("config.Config")

    # Habilita CORS
    CORS(app)

    # Registro de rutas
    from app.routes.recommendation import recommendation_bp
    app.register_blueprint(recommendation_bp)

    return app

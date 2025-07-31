from flask import Blueprint, jsonify

recommendation_bp = Blueprint("recommendation", __name__)

@recommendation_bp.route("/health", methods=["GET"])
def health_check():
    return jsonify({"status": "ok"}), 200

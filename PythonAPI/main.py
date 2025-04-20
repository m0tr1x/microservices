from fastapi import FastAPI, Request
import asyncpg
import os

app = FastAPI()

DB_URL = os.getenv("DATABASE_URL")

@app.on_event("startup")
async def startup():
    conn = await asyncpg.connect(DB_URL)
    await conn.execute("""
        CREATE TABLE IF NOT EXISTS processed_data (
            id SERIAL PRIMARY KEY,
            original_data TEXT NOT NULL,
            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
        );
    """)
    await conn.close()
    print("Таблица processed_data проверена или создана")

@app.post("/process")
async def process_data(request: Request):
    data = await request.json()

    conn = await asyncpg.connect(DB_URL)
    await conn.execute('''
        INSERT INTO processed_data (original_data)
        VALUES ($1)
    ''', str(data))

    await conn.close()
    return {"status": "ok", "received": data}

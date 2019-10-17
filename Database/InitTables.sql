CREATE TABLE IF NOT EXISTS  Users(
  discord_id INTEGER PRIMARY KEY,
  discord_alias TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Splits(
  discord_id INTEGER,
  split_amt INTEGER,
  FOREIGN KEY(discord_id) REFERENCES Users(discord_id)
);
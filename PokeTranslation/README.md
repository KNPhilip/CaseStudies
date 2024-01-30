# PokeTranslate API Documentation

## Overview

The PokeTranslate API provides a service for translating Pokémon descriptions into both Shakespearean and normal language.

## Get running

First clone the repository to your local machine, then go to the root level and run `docker compose up -d`.

After a while, you should have a running .NET API within a Docker container.

## Base URL

The base URL for the API is `http://localhost:6001`.

## Endpoint

### Translate Pokémon Description

Translate a Pokémon description into both Shakespearean and normal language.

- **Endpoint:** `api/v1/poketranslate/{pokemonName}`
- **Method:** `GET`

#### Request Parameters

- `{pokemonName}`: The name of the Pokémon whose description is to be translated.

#### Example Request

```http
http://localhost:6001/api/v1/poketranslate/charizard

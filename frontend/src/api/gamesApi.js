const API_URL = `${import.meta.env.VITE_API_URL}/games`;

export async function getAllGames(genre, platform, sort) {
    const params = new URLSearchParams();

    if (genre) params.append('genre', genre);
    if (platform) params.append('platform', platform);
    if (sort) params.append('sort', sort);

    const url = params.toString()
        ? `${API_URL}?${params}`
        : API_URL;

    const response = await fetch(url);

    if (!response.ok) {
        throw new Error('Error al obtener juegos');
    }

    return await response.json();
}

export async function getGameById(id) {
    const response = await fetch(`${API_URL}/${id}`);

    if (!response.ok) {
        throw new Error('Error al obtener el juego');
    }

    return await response.json();
}


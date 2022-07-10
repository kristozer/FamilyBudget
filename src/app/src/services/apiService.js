export function get(url) {
    return fetch(url).then(_parseJson);
}

export function post(url, data) {
    const fetchParams = {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
    return fetch(url, fetchParams).then(_parseJson);
}

function _isJson(response) {
    const contentType = response?.headers?.get(`Content-Type`) || ``;

    return contentType.includes(`application/json`) || contentType.includes(`application/x-javascript`);
}

function _parseJson(response) {
    if (_isJson(response)) {

        return response.json();
    }

    return Promise.resolve();
}

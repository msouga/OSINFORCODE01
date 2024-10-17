import { getEnvironmentVariables, formatEnvironmentVariables } from './envVariables';

describe('Pruebas de variables de entorno', () => {
  test('getEnvironmentVariables devuelve un objeto con variables de entorno', async () => {
    const variables = await getEnvironmentVariables();
    expect(variables).toBeDefined();
    expect(Object.keys(variables).length).toBeGreaterThan(0);
    expect(variables['NODE_ENV']).toBe('development');
  });

  test('formatEnvironmentVariables formatea correctamente las variables', async () => {
    const mockVariables = {
      'TEST_VAR1': 'valor1',
      'TEST_VAR2': '',
      'TEST_VAR3': 'valor3'
    };

    const formattedResult = await formatEnvironmentVariables(mockVariables);
    expect(formattedResult).toContain('<h1>Variables de Entorno</h1>');
    expect(formattedResult).toContain('<p><strong>TEST_VAR1:</strong> valor1</p>');
    expect(formattedResult).toContain('<p><strong>TEST_VAR2:</strong> <vacio></p>');
    expect(formattedResult).toContain('<p><strong>TEST_VAR3:</strong> valor3</p>');
  });
});
